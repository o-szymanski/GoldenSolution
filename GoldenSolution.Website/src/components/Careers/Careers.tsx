import React from "react";
import { useQuery } from "@tanstack/react-query";
import fetchCareers from "./fetchCareers.ts";
import { ICareerRecord } from "./APIResponsesTypes.ts";
import CareerRecord from "./CareerRecord.tsx";

const Careers = (): React.ReactElement => {
  const { isPending, isError, data, error } = useQuery({
    queryKey: ["careers"],
    queryFn: fetchCareers,
  });

  if (isPending) {
    return <span>Loading...</span>;
  }

  if (isError) {
    console.error("Error - " + error.message);
  }

  // @todo fix this, mocked API response6
  const careers = data?.careers ?? [
    {
      id: 1,
      title: "Test job 1",
      description: "Test job 1 description",
      location: "Warsaw",
      tags: ["remote"],
      salary: "21,37 PLN/h",
      contact: "Papaj",
    },
    {
      id: 2,
      title: "Test job 2",
      description: "Test job 2 description",
      location: "Warsaw",
      tags: ["on-site"],
      salary: "150 PLN/h",
      contact: "Miras",
    },
  ];
  console.log(careers);

  return (
    <div>
      {!careers.length ? (
        <h1>No careers available</h1>
      ) : (
        careers.map((career: ICareerRecord) => (
          <CareerRecord
            id={career.id}
            title={career.title}
            description={career.description}
            location={career.location}
            key={career.id}
          />
        ))
      )}
    </div>
  );
};

export default Careers;
