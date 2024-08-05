import React from "react";
import NavigationBar from "../components/NavigationBar/NavigationBar.tsx";
import SlideToTheTopButton from "../components/SlideToTheTop/SlideToTheTopButton.tsx";
import Footer from "../components/Footer/Footer.tsx";
import CareersOfferComponent from "../components/Careers/CareerOffer.tsx";
import queryClient from "./queryClient.ts";
import { QueryClientProvider } from "@tanstack/react-query";

const CareerOffer = (): React.ReactElement => {
  return (
    <>
      <QueryClientProvider client={queryClient}>
        <NavigationBar />
        <CareersOfferComponent />
        <SlideToTheTopButton />
        <Footer />
      </QueryClientProvider>
    </>
  );
};

export default CareerOffer;
