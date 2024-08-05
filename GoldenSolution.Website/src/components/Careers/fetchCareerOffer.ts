import { QueryFunction } from "@tanstack/react-query";
import { ICareerRecord } from "./APIResponsesTypes.ts";

const fetchCareerOffer: QueryFunction<
  ICareerRecord,
  ["careerOfferRecord", string]
> = async ({ queryKey }) => {
  const id = queryKey[1];
  // @todo add API endpoint for careers
  const apiRes = await fetch(`http://localhost:8080/api/v1/careers/${id}`);

  if (!apiRes.ok) {
    // @todo handle real API response
    // throw new Error("Failed to fetch careers!");
    return new Response("{}").json();
  }

  return apiRes.json();
};

export default fetchCareerOffer;
