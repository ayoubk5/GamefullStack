import { List, ListItem, Image, HStack, Button, Heading } from "@chakra-ui/react";
import useGenres, { Genre } from "../hooks/useGenres";
import getCroppedImageUrl from "../services/image-url";
interface Props{
  selectGenre:(genre:Genre ) => void,
  selectedGenre: Genre | null;
}
const GenreList = ({selectedGenre,selectGenre}:Props) => {
  const { data,error } = useGenres();
  if(error) return null;
  return (
    <>
    <Heading fontSize='2xl' marginBottom={3}>Genres</Heading>
      <List>
        {data.map((genre) => (
          <ListItem key={genre.id} paddingY="5px">
            <HStack>
              <Image
                boxSize="32px"
                borderRadius={8}
                src={getCroppedImageUrl(genre.image)}
                objectFit='cover'
              />
              <Button whiteSpace='normal' textAlign='left' fontWeight={genre.id === selectedGenre?.id ?"bold":"normal"} variant='link' onClick={()=>selectGenre(genre)}>{genre.name}</Button>
            </HStack>
          </ListItem>
        ))}
      </List>
    </>
  );
};

export default GenreList;
