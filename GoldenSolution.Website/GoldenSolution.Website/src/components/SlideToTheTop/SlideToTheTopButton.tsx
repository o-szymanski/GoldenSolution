import { useEffect, useState } from 'react'
import styles from './SlideToTheTopButton.module.css'

function SlideToTheTopButton() {
    const [slideToTheTopButton, setSlideToTheTopButton] = useState(false);
    useEffect(() => {
        window.addEventListener("scroll", () => {
            if (window.scrollY > 100) {
                setSlideToTheTopButton(true)
            }
            else {
                setSlideToTheTopButton(false)
            }
        })
    })

    const slideToTheTop = () => {
        window.scrollTo({
            top: 0,
            behavior: "smooth"
        })
    }

    return <div>
        {slideToTheTopButton && (
            <button className={styles.SlideToTheTopButton} onClick={slideToTheTop}>^</button>
        )}
    </div>
}

export default SlideToTheTopButton;
