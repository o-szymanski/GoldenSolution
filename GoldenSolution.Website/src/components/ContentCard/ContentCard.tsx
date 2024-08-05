import React from "react";
import logoImage from "../../assets/socials/logo.svg"
import styles from "./ContentCard.module.css"
import { Link } from "react-router-dom";

interface Props {
    cardId: string,
    linkTo?: string
    cardImage?: string
}
function ContentCard({ cardId, linkTo, cardImage }: Props): React.ReactElement {
    if (!cardImage) {
        cardImage = logoImage
    }


    return (
        <div className={styles.contentCard} id={cardId}>
            <Link to={linkTo ? linkTo : "/"}>
                <div className={styles.imageContainer}>
                    <img src={cardImage} alt="card image" className={styles.cardImage} />
                </div>
            </Link>
            <div className={styles.contentCardText}>
                <h1>Content Card Text Title</h1>
                <h3>Content Card Text Body</h3>
            </div>
        </div>
    );
}

export default ContentCard;