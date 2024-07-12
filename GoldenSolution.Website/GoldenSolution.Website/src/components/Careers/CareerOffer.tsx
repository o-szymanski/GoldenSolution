import React from "react";
import { useParams } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import fetchCareerOffer from "./fetchCareerOffer.ts";

const CareerOffer = (): React.ReactElement => {
  const { careerId } = useParams();

  if (!careerId) {
    throw new Error("No id for CareerOffer");
  }

  const { isPending, isError, data, error } = useQuery({
    queryKey: ["careerOfferRecord", careerId],
    queryFn: fetchCareerOffer,
  });

  if (isPending) {
    return <span>Loading...</span>;
  }

  if (isError) {
    console.error("Error - " + error.message);
  }

  const careerOffer = data ?? {
    id: 1,
    title: "string",
    description: "string",
    location: "string",
    tags: ["string"],
    salary: "string",
    contact: "string",
  };
  console.log(careerOffer);
  return (
    <div>
      <div>
        <h1>
          {careerOffer.id} - {careerOffer.title}
        </h1>
        <h3>{careerOffer.description}</h3>
        <div>
          {careerOffer.location} -{" "}
          {careerOffer.tags?.map((tag) => <p key={tag}>{tag}</p>)}
        </div>
        <h4>{careerOffer.salary}</h4>
        <h4>{careerOffer.contact}</h4>
      </div>
    </div>
  );
};

export default CareerOffer;
