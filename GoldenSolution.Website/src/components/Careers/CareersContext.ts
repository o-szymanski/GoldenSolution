import { createContext } from "react";
import { ICareerLocation } from "./APIResponsesTypes.ts";

const SelectedCareerLocation = createContext<
  [ICareerLocation | null, (selectedCareerLocation: ICareerLocation) => void]
>([
  {
    name: "Wadowice",
  },
  () => {},
]);

export default SelectedCareerLocation;
