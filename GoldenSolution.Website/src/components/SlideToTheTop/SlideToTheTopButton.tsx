import React, { useState, useEffect, useCallback } from "react";
import styles from "./SlideToTheTopButton.module.css";

const SlideToTheTopButton: React.FC = () => {
  const [isVisible, setIsVisible] = useState(false);

  const toggleVisibility = useCallback(() => {
    const windowHeight = window.innerHeight;
    const documentHeight = document.documentElement.scrollHeight;
    const scrollY = window.scrollY;
    const scrollThreshold = documentHeight * 0.75;

    if (scrollY + windowHeight > scrollThreshold) {
      setIsVisible(true);
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
    const handleScroll = () => {
      toggleVisibility();
    };

    window.addEventListener("scroll", handleScroll);
    toggleVisibility();

    return () => {
      window.removeEventListener("scroll", handleScroll);
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
