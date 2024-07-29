import React from "react";
import { ICareerRecord } from "./APIResponsesTypes.ts";
import { Link } from "react-router-dom";

const CareerRecord = (props: ICareerRecord): React.ReactElement => {
  return (
    <Link to={`/careers/${props.id}`}>
      <div>
        <h1>{props.title}</h1>
        <h2>
          {!props.tags
            ? ""
            : props.tags.map((tag) => (
                <div key={props.id}>
                  <p>{tag}</p>
                </div>
              ))}
        </h2>
        <h3>{props.description}</h3>
        <p>{props.salary}</p>
        <p>{props.contact}</p>
      </div>
    </Link>
  );
};

export default CareerRecord;
