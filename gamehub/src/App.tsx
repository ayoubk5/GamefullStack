import { Grid, GridItem, Show } from "@chakra-ui/react";
import "./App.css";
import NavBar from "./components/NavBar";
import GenreList from "./components/GenreList";
import {  useState } from "react";
import { Genre } from "./hooks/useGenres";
import useGames, { Platform } from "./hooks/useGames";

import { Route, Routes, useSearchParams } from "react-router-dom";
import CreateGameForm from "./components/CreateGameForm";
import GameComponent from "./components/GameComponent";
import { FormData } from "./components/CreateGameForm";

import gameService from "./services/game-service";
import UpdateGame from "./components/UpdateGame";

export interface GameQuery {
  genre: Genre | null;
  platform: Platform | null;
  order: string;
  searchText: string;
  game:number
}
export interface GameCreateDto {
  id: number;
  name: string;
  rating: number;
  image: string;
  platformes: Platform[];
  genreId: number;
}
function App() {
  const [gameQuery, setGameQuery] = useState<GameQuery>({} as GameQuery);
  const [searchparams] = useSearchParams();
  const { data, error, isLoading, setData } = useGames(gameQuery);
  const id = searchparams.get("id") ;
  let game = data.filter(d => d.id == (id?+id:0))[0]






  const handleUpdateGame=(game: GameCreateDto)=>{
    const originData = data;
    gameService.update(game)
    .then((res)=>{
      setData([...data,res.data])
      setGameQuery({...gameQuery,game:game.id})})
      .catch(_ => setData(originData))
    setGameQuery({...gameQuery,game:game.id})
  }
  const handleAddGame = (game: FormData) => {
    const maper: GameCreateDto = {
      id: game.Id,
      name: game.Name,
      image: game.Image,
      rating: game.Rating,
      genreId: game.Genre,
      platformes: game.Platforms,
    };
    const originData = data;
    gameService
      .add(maper)
      .then((res) => {
        setData([...data, res.data.data]);
        setGameQuery({ ...gameQuery, game: maper.id });
      })
      .catch((_) => {
        setData(originData);
      });
  };
  return (
    <>
      <Grid
        templateAreas={{
          base: `"nav" "main"`,
          lg: `"nav nav" "aside main"`,
        }}
        templateColumns={{
          base: "1fr",
          lg: "200px 1fr",
        }}
      >
        <GridItem area="nav">
          <NavBar
            onSearch={(searchText) =>
              setGameQuery({ ...{} as GameQuery, searchText })
            }
          />
        </GridItem>
        <Show above="lg">
          <GridItem area="aside" paddingX={5}>
            <GenreList
              selectedGenre={gameQuery.genre}
              selectGenre={(genre) => {
                setGameQuery({ ...{} as GameQuery, genre })
              }}
            />
          </GridItem>
        </Show>
        <GridItem area="main" marginX={10}>
          <Routes>
            <Route
              path="/"
              element={
                <GameComponent
                  gameQuery={gameQuery}
                  setGameQuery={setGameQuery}
                  data={data}
                  error={error}
                  isLoading={isLoading}
                  setData={setData}
                />
              }
            />
            <Route
              path="/createGame"
              element={<CreateGameForm gameQuery={gameQuery} games={data} onAdd={handleAddGame} />}
            />
            <Route
              path="/update"
              element={<UpdateGame gameQuery={gameQuery} game={game}  onUpdate={handleUpdateGame}/>}
            />
          </Routes>
        </GridItem>
      </Grid>
    </>
  );
}

export default App;