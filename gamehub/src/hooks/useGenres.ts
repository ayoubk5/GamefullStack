import { useEffect, useState } from 'react';
import genres from '../data/genres'
import genreService from '../services/genre-service';
import { CanceledError } from 'axios';
import apiClient from '../services/api-client';
export interface Genre {
  id: number;
  name: string;
  image: string;
}

const useGenres = () => {

  const [data, setData] = useState<Genre[]>([]);
  const [error, setError] = useState("");
  const [isLoading, setLoading] = useState(false);
  const controller = new AbortController();
  useEffect(() => {
    setLoading(true);
    apiClient
      .get<Genre[]>("/Genre/All", { signal: controller.signal })
      .then((res) => {
        setData(res.data);
        setLoading(false);
        console.log(res.data)
      })
      .catch((err) => {
        if (err instanceof CanceledError) return;
        setError(err.message);
        setLoading(false);
      });
    return () => controller.abort();
  },[]);
  return { data, error, isLoading,setData };
}
export default useGenres;
