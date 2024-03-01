import styles from "./NavigationBar.module.css"
import logoImage from "../../assets/socials/logo.svg"
import { Link } from "react-router-dom"
import React from "react";
import LanguageSelector from "../LanguageSelector/LanguageSelector"
import { useTranslation } from "react-i18next";

function NavigationBar(): React.ReactElement {
    const { t } = useTranslation();
    const logo: React.ReactElement = <div className={styles.navigationBarLogo}>
        <img alt="Golden Solution Logo" src={logoImage} className={styles.navigationBarLogoImage}></img>
    </div>
    const navigationBarItems: React.ReactElement = <div className={styles.navigationBarMenu}>
        <Link to='/Menu' className={styles.navigationBarMenuItem}> {t("navigationBar.menu")} </Link>
        <Link to='/Restaurants' className={styles.navigationBarMenuItem}> {t("navigationBar.restaurants")} </Link>
        <Link to='/Login' className={styles.navigationBarMenuItem}> {t("navigationBar.login")} </Link>
        <Link to='/Register' className={styles.navigationBarMenuItem}> {t("navigationBar.register")} </Link>
        <LanguageSelector></LanguageSelector>
    </div>

    return (
        <nav className={styles.navigationBar}>
            {logo}
            {navigationBarItems}
        </nav>
    );
}

export default NavigationBar