import { useEffect, useState } from 'react'
import styles from './SlideToTheTopButton.module.css'
import React from "react";

function SlideToTheTopButton(): React.ReactElement {
    const [slideToTheTopButton, setSlideToTheTopButton] = useState(false);
    useEffect(() => {
        window.addEventListener("scroll", () => {
            if (window.scrollY > 100) {
                window.addEventListener("scroll", () => window.scrollY > 100 ? setSlideToTheTopButton(true) : setSlideToTheTopButton(false));
            }
        })
    })

    const slideToTheTop = () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        })
    }

    return (
        <div>
            {slideToTheTopButton && (
                <button className={styles.slideToTheTopButton} onClick={slideToTheTop}>^</button>
            )}
        </div>
    );
}

export default SlideToTheTopButton;
