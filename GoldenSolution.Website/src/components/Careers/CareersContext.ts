import { createContext } from "react";
import { ICareerLocation } from "./APIResponsesTypes.ts";

const SelectedCareerLocation = createContext<
  [ICareerLocation | null, (selectedCareerLocation: ICareerLocation) => void]
>([
  {
    id: "1", // Replace with a suitable default value or type
    name: "Wadowice",
  },
  () => { },
]);

export default SelectedCareerLocation;
