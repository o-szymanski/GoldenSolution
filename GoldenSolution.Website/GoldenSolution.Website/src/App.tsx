import SlideToTheTopButton from './components/SlideToTheTop/SlideToTheTopButton';
import Footer from "./components/Footer/Footer.tsx";
import NavigationBar from "./components/NavigationBar/NavigationBar.tsx"
import ContentSection from "./components/ContentSection/ContentSection.tsx";
import './App.css'
import React from "react";

function App(): React.ReactElement {
    return (
    <>
      <NavigationBar />
      <SlideToTheTopButton />
      <ContentSection />
      <Footer />
    </>
  )
}

export default App
