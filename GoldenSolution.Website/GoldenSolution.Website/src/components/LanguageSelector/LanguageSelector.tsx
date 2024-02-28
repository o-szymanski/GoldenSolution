import React from "react";
import { useTranslation } from "react-i18next";
import styles from "./LanguageSelector.module.css"

const LanguageSelector = (): React.ReactElement => {
    const { i18n } = useTranslation();
    const changeLanguage = async () => {
        const element = document.getElementById("LanguageSelector") as HTMLInputElement;
        element.checked ? await i18n.changeLanguage("pl") : await i18n.changeLanguage("en")
    };

    return (
        <div className={styles.languageSelector}>
            <input className={styles.languageSelectorInput} type="checkbox" id="LanguageSelector" onClick={() => void changeLanguage()} />
            <label className={styles.languageSelectorLabel} htmlFor="LanguageSelector" />
        </div>
    );
}

export default LanguageSelector;