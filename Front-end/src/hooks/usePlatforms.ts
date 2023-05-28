import { useEffect, useState } from "react";
import platforms from "../data/platforms";
import platformService from "../services/platform-service";
import { CanceledError } from "axios";
import apiClient from "../services/api-client";
export interface Platform {
  id: number;
  name: string;
  slug: string;
}

// const usePlatforms = () => ({data:platforms, isLoading: false, error:null});
const usePlatforms=() => {
  const [data, setData] = useState<Platform[]>([]);
  const [error, setError] = useState("");
  const [isLoading, setLoading] = useState(false);
  const controller = new AbortController();
  useEffect(() => {
  setLoading(true);
  apiClient
    .get<Platform[]>("/Platforme/All", { signal: controller.signal })
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
export default usePlatforms;