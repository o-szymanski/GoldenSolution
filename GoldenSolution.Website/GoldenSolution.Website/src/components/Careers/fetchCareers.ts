import { QueryFunction } from "@tanstack/react-query";
import { ICareerAPIResponse } from "./APIResponsesTypes.ts";

const fetchCareers: QueryFunction<
  ICareerAPIResponse,
  ["careers"]
> = async () => {
  // @todo add API endpoint for careers
  const apiRes = await fetch("http://localhost:8080/api/v1/careers");

  if (!apiRes.ok) {
    // @todo handle real API response
    // throw new Error("Failed to fetch careers!");
    return new Response(
      '{"careers": [{"id": 1,"title": "Test job 1","description": "Test job 1 description","location": "Warsaw","tags": ["remote"],"salary": "21,37 PLN/h","contact": "Papaj"},{"id": 2,"title": "Test job 2","description": "Test job 2 description","location": "Warsaw","tags": ["on-site"],"salary": "150 PLN/h","contact": "Miras"}]}',
    ).json();
  }

  return apiRes.json();
};

export default fetchCareers;
