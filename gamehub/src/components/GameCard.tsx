import {
  Card,
  Image,
  CardBody,
  Heading,
  IconButton,
  Flex,
  Box,
} from "@chakra-ui/react";
import { HStack } from "@chakra-ui/react";
import PlatformIconList from "./PlatformIconList";
import CriticScore from "./CriticScore";
import getCroppedImageUrl from "../services/image-url";
import Emoji from "./Emoji";
import { BiEdit } from "react-icons/bi";
import { MdDelete } from "react-icons/md";
import { GameCreateDto } from "../App";
interface Props {
  game: GameCreateDto;
  handleDelete:(id:number)=>void,
  handleUpdate:(id:number)=>void
}
const GameCard = ({ game,handleDelete,handleUpdate }: Props) => {
  const parser = parseInt((game.rating*5/100).toString())
  const rating = game.rating*5/100 - parser>=0? parser+1 : parser
  return (
    <>
      <Card height={450}>
        <>
          <Flex justifyContent="flex-end">
            <IconButton
              size={"lg"}
              p="2.5"
              bg="slate"
              rounded="xl"
              _hover={{ rounded: "3xl", bg: "#3949AB", color: "white" }}
              transition="all 300ms"
              color="#3949AB"
              icon={<BiEdit />}
              aria-label="Edit"
              onClick={()=>handleUpdate(game.id)}
            />
            <IconButton
              size={"lg"}
              p="2.5"
              bg="slate"
              rounded="xl"
              _hover={{ rounded: "3xl", bg: "red.500", color: "white" }}
              transition="all 300ms"
              color="red.600"
              icon={<MdDelete />}
              aria-label="Delete"
              ml={3}
              onClick={()=>handleDelete(game.id?game.id:0)}
            />
          </Flex>
          <Box
            justifySelf="flex-end"
            position="absolute"
            top={3}
            right={3}
          ></Box>
        </>

        <Image src={getCroppedImageUrl(game.image)}  height={200} width={'fit-content'} margin='auto'/>
        <CardBody>
          <HStack justifyContent="space-between" marginBottom={3}>
            <PlatformIconList
              platforms={game.platformes.map((p) => p)}
            />
            <CriticScore score={game.rating} />
          </HStack>
          <Heading fontSize="2xl">
            {game.name}
            <Emoji rating={rating} />
          </Heading>
        </CardBody>
      </Card>
    </>
  );
};

export default GameCard;
