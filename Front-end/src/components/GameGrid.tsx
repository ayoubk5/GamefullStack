import { SimpleGrid } from "@chakra-ui/react";
import GameCard from "./GameCard";
import GameCardSkeleton from "./GameCardSkeleton";
import GameCardContainer from "./GameCardContainer";
import { GameCreateDto } from "../App";
interface Props{
  data:GameCreateDto[],
  error:string,
  isLoading:boolean,
  onDelete:(id:number) => void
  onUpdate:(id:number) => void
}
const GameGrid = ({data,isLoading,onDelete,onUpdate}:Props) => {
  const skeletons = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
  return (
      <SimpleGrid
        columns={{ sm: 1, md: 2, lg: 3, xl: 4 }}
        paddingY={10}
        spacing={6}
      >
        {isLoading &&
          skeletons.map((skeleton) => (
            <GameCardContainer key={skeleton}>
              <GameCardSkeleton />
            </GameCardContainer>
          ))}
        {data.map((game) => (
          <GameCardContainer key={game.id}>
            <GameCard game={game} handleDelete={onDelete} handleUpdate={onUpdate}/>
          </GameCardContainer>
        ))}
      </SimpleGrid>
  );
};

export default GameGrid;
