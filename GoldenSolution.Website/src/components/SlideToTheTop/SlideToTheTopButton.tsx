import React, { useState, useEffect, useCallback } from "react";
import styles from "./SlideToTheTopButton.module.css";

const SlideToTheTopButton: React.FC = () => {
  const [isVisible, setIsVisible] = useState(false);

  const toggleVisibility = useCallback(() => {
    const windowHeight = window.innerHeight;
    const documentHeight = document.documentElement.scrollHeight;
    const scrollY = window.scrollY;
    const scrollThreshold = documentHeight * 0.75;
    const minPageHeight = windowHeight * 1.5;

    if (documentHeight > minPageHeight) {
      if (scrollY + windowHeight > scrollThreshold) {
        setIsVisible(true);
      } else {
        setIsVisible(false);
      }
    } else {
      setIsVisible(false);
    }
  }, []);

  const handleScrollToTop = useCallback(() => {
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  }, []);

  useEffect(() => {
    window.addEventListener("scroll", toggleVisibility);
    toggleVisibility();

    return () => {
      window.removeEventListener("scroll", toggleVisibility);
    };
  }, [toggleVisibility]);

  return (
    <div>
      {isVisible && (
        <button onClick={handleScrollToTop} className={styles.button}>
          ^
        </button>
      )}
    </div>
  );
};

export default SlideToTheTopButton;
