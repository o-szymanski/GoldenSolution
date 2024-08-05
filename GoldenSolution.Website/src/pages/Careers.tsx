import React, { useState } from "react";
import NavigationBar from "../components/NavigationBar/NavigationBar.tsx";
import SlideToTheTopButton from "../components/SlideToTheTop/SlideToTheTopButton.tsx";
import Footer from "../components/Footer/Footer.tsx";
import CareersComponent from "../components/Careers/Careers.tsx";
import { QueryClientProvider } from "@tanstack/react-query";
import SearchCareers from "../components/Careers/SearchCareers.tsx";
import CareersContext from "../components/Careers/CareersContext.ts";
import { ICareerLocation } from "../components/Careers/APIResponsesTypes.ts";
import queryClient from "./queryClient.ts";
const Careers = (): React.ReactElement => {
  const selectedLocation = useState(null as ICareerLocation | null);

  return (
    <>
      <QueryClientProvider client={queryClient}>
        <CareersContext.Provider value={selectedLocation}>
          <NavigationBar />
          <SearchCareers />
          <CareersComponent />
          <SlideToTheTopButton />
          <Footer />
        </CareersContext.Provider>
      </QueryClientProvider>
    </>
  );
};

export default Careers;
