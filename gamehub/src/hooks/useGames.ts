import { GameCreateDto, GameQuery } from "../App";
import useData from "./useData";
export interface Platform {
  id: number;
  name: string;
}
export interface Game {
  id: number;
  name: string,
  rating: number,
  image: string,
  platformes: Platform[],
  genreId: number
}

const useGames = (
  gameQuery?: GameQuery
  ) =>{   
    let endPoint = gameQuery?.platform?.id?"/Platforme/"+gameQuery?.platform?.id:gameQuery?.searchText? "/Games/Search/"+gameQuery?.searchText :
    gameQuery?.genre?.id ?"/Genre/"+gameQuery?.genre?.id  : "/Games";      
  return useData<GameCreateDto>(

    endPoint,
    {
      params: {
        genres: gameQuery?.genre?.id,
        platforms: gameQuery?.platform?.id,
        ordering: gameQuery?.order,
        search:gameQuery?.searchText,
        game:gameQuery?.game
      },
    },
    [gameQuery]
    )
  }

export default useGames;