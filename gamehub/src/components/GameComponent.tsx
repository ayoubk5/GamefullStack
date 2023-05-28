import GameHeading from "./GameHeading";
import PlatformSelector from "./PlatformSelector";
import GameGrid from "./GameGrid";
import { Box, Flex} from "@chakra-ui/react";
import { GameCreateDto, GameQuery } from "../App";
import gameService from "../services/game-service";
import {createSearchParams, useNavigate } from "react-router-dom";
interface Props{
  gameQuery:GameQuery,
  setGameQuery:(gameQuery:GameQuery) => void,
  data:GameCreateDto[],
  error:string,
  isLoading:boolean,
  setData:(data:GameCreateDto[])=>void
}
const GameComponent = ({ data, error, isLoading,setData,gameQuery,setGameQuery }:Props) => {
  const navigate = useNavigate();
  const handleNavigate=(id:number)=>{
    navigate({
      pathname:"/update",
      search: createSearchParams({
        id: id.toString()
      }).toString()
    })
  }
  const handleUpdate = (id: number) =>{
    handleNavigate(id);
  }
  const handleDelete = (id: number) => {
    const originalGames = [...data];
    setData(data.filter((d) => d.id !== id));
    gameService.delete(id)
    .then()
    .catch(() => {
      setData(originalGames);
    })
    console.log(id)
    setGameQuery({...gameQuery,game:id})
  };
  return (
    <>
      <GameHeading gameQuery={gameQuery} />
      <Flex>
        <Box marginRight={5}>
          <PlatformSelector
            selectedPlatform={gameQuery.platform}
            onSelectedPlatform={(platform) =>{
              setGameQuery({ ...{} as GameQuery, platform })
            }
            }
          />
        </Box>
      </Flex>
      <GameGrid 
              data={data} 
              error={error} 
              isLoading={isLoading} 
              onDelete={handleDelete}
              onUpdate={handleUpdate}/>
    </>
  );
};

export default GameComponent;