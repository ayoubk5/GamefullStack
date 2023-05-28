import {
  Button,
  FormControl,
  FormErrorMessage,
  FormHelperText,
  FormLabel,
  Input,
  NumberInput,
} from "@chakra-ui/react";
import { Select as ChakraSelect } from "@chakra-ui/react";
import { FormEvent, useEffect, useState } from "react";
import useGenres from "../hooks/useGenres";
import { Platform } from "../hooks/useGames";
import usePlatforms from "../hooks/usePlatforms";
import Uploader from "./Uploader";
import SelectMultipleChoice, { Selected } from "./SelectMultipleChoice";
import { GameCreateDto, GameQuery } from "../App";
import { useNavigate } from "react-router-dom";

export interface FormData {
  Id: number;
  Name: string;
  Rating: number;
  Genre: number;
  Platforms: Platform[];
  Image: string;
}
interface Props {
  gameQuery:GameQuery,
  game: GameCreateDto,
  onUpdate: (game: GameCreateDto) => void
}

const UpdateGame = ({ onUpdate,game }: Props) => {

  const navigate = useNavigate();

const [gameState, setGameState] = useState<GameCreateDto>(game);
  const { data: platformes } = usePlatforms();
  const { data } = useGenres();
  const [selectedOptions, setSelectedOptions] = useState<Selected[]>(gameState.platformes.map((option: Platform) => ({
    value: option.id,
    label: option.name,
  })));

  useEffect(() => {
    const ids = selectedOptions.map((s: { value: number }) => s?.value);
    const platf = platformes
      .filter((p: Platform) => ids.includes(p.id))
      .map((p) => {
        const maper: Platform = {
          name: p.name,
          id: p.id,
        };
        return maper;
      });
    setGameState({
      ...gameState,
      platformes: platf,
    });
  }, [selectedOptions]);
  const handleMultiSelectionChange = (platforms: Selected[]) => {
    setSelectedOptions(platforms);
  };
  const handleFile = (image: string) => {
    setGameState({ ...gameState, image: image });
  };

  const [rating, setRating] = useState("");

  const handleSubmit = (event: FormEvent) => {
    event.preventDefault();
    if (!isValid) {
      setRating("");
    } else {
      onUpdate(gameState);
      if(gameState != game)
      navigate("/")
      
    }
  };
  const isValid = +rating >= 0 && +rating <= 100;
  return (
    <>
      <form onSubmit={handleSubmit} id="createGame">
        <FormControl isRequired>
          <FormLabel>Name</FormLabel>
          <Input
            value={gameState.name}
            onChange={(event) =>
              setGameState({ ...gameState, name: event.target.value })
            }
            type="text"
            placeholder="Game name"
          />
        </FormControl>
        <FormControl isRequired isInvalid={!isValid}>
          <FormLabel>Rating</FormLabel>
          <NumberInput max={100} min={0}>
            <Input
              type="number"
              value={gameState.rating}
              onChange={(event) => {
                setRating(event.target.value);
                setGameState({
                  ...gameState,
                  rating: +event.target.value,
                });
              }}
            />
          </NumberInput>
          {isValid ? (
            <FormHelperText>rating should be between 0 and 100</FormHelperText>
          ) : (
            <FormErrorMessage>
              rating should be between 0 and 100
            </FormErrorMessage>
          )}
        </FormControl>
        <FormControl isRequired>
          <FormLabel>Genre</FormLabel>
          <ChakraSelect
            placeholder="-- Select Genre --"
            value={gameState.genreId}
            onChange={(event) =>
              setGameState({ ...gameState, genreId: +event.target.value })
            }
          >
            {data.map((genre) => (
              <option value={genre.id} key={genre.id}>
                {genre.name}
              </option>
            ))}
          </ChakraSelect>
        </FormControl>
        <FormControl isRequired>
          <FormLabel>Platforms</FormLabel>
          <SelectMultipleChoice
            platforms={selectedOptions}
            handleMultiChoice={handleMultiSelectionChange}
          />
        </FormControl>
        <Uploader image={gameState.image} handleFile={handleFile} />
        <Button
          width="full"
          mt={4}
          type="submit"
          colorScheme="teal"
          variant="outline"
        >
          Submit
        </Button>
      </form>
    </>
  );
};

export default UpdateGame;
