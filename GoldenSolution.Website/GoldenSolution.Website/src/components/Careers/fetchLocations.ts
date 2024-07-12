import { QueryFunction } from "@tanstack/react-query";
import { ICareerLocationsAPIResponse } from "./APIResponsesTypes.ts";

const fetchLocations: QueryFunction<
  ICareerLocationsAPIResponse,
  ["locations"]
> = async () => {
  // @todo add API endpoint for careers
  const apiRes = await fetch("http://localhost:8080/api/v1/careers");

  if (!apiRes.ok) {
    // @todo handle real API response
    // throw new Error("Failed to fetch careers!");
    return new Response(
      '{"locations": [{"id": 1,"name": "Wadowice"},{"id": 2,"name": "Warsaw"},{"id": 3,"name": "Kraków"}]}',
    ).json();
  }

  return apiRes.json();
};

export default fetchLocations;
