import React, { useState } from "react";
import { useContext } from "react";
import { useQuery } from "@tanstack/react-query";
import CareersContext from "./CareersContext.ts";
import fetchLocations from "./fetchLocations.ts";
import { ICareerLocation } from "./APIResponsesTypes.ts";

const SearchCareers = (): React.ReactElement => {
  const [careersParams, setCareersParams] = useState({
    location: "" as string,
  });
  const [selectedCareerLocation, setSelectedCareerLocation] =
    useContext(CareersContext);
  const { isPending, isError, data, error } = useQuery({
    queryKey: ["locations"],
    queryFn: fetchLocations,
  });
  if (isPending) {
    return <span>Loading...</span>;
  }

  if (isError) {
    console.error("Error - " + error.message);
  }

  console.log("data");
  console.log(data);
  console.log("careersParams");
  console.log(careersParams);
  console.log("selectedCareerLocation");
  console.log(selectedCareerLocation);

  const locations: ICareerLocation[] = data?.locations ?? [
    { id: 1, name: "Wadowice" },
    { id: 2, name: "Warsaw" },
    { id: 3, name: "Kraków" },
  ];

  return (
    <div>
      <div>
        <form
          onSubmit={(event) => {
            event.preventDefault();
            const formData = new FormData(event.currentTarget);
            console.log("formData");
            console.log(formData);

            const obj = {
              location: formData.get("locations")?.toString() ?? "",
            };
            setCareersParams(obj);
            setSelectedCareerLocation({ id: 1, name: obj.location });
          }}
        >
          <input id="search" placeholder="Search" />
          <select
            id="locations"
            disabled={locations.length === 0}
            name="locations"
          >
            <option />
            {locations.map((location) => (
              <option data-id={location.id} key={location.name}>
                {location.name}
              </option>
            ))}
          </select>
          <button>Submit</button>
        </form>
      </div>
      <div>
        Location:
        {selectedCareerLocation ? (
          <h3>{selectedCareerLocation.name}</h3>
        ) : (
          <h3>No Location selected</h3>
        )}
      </div>
    </div>
  );
};

export default SearchCareers;
