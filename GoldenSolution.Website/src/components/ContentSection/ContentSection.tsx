import React from "react";
import ContentCard from "../ContentCard/ContentCard.tsx";
import styles from "./ContentSection.module.css"

function ContentSection(): React.ReactElement {
    return (
        <div id="content-section" className={styles.contentSectionContainer}>
            <div id="content-section-header" className={styles.contentSectionContainerHeader}>
                <h1>Content Section Title</h1>
            </div>
            <div id="content-section-body" className={styles.contentSectionContainerBody}>
                <ContentCard cardId="card-1" linkTo="/Menu"/>
                <ContentCard cardId="card-2" linkTo="/Restaurants"/>
                <ContentCard cardId="card-3" />
            </div>
        </div>
    )
}

export default ContentSection