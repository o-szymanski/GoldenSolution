import styles from "./NavigationBar.module.css";
import logoImage from "../../assets/socials/logo.svg";
import { Link } from "react-router-dom";
import React, { useEffect, useState } from "react";
import LanguageSelector from "../LanguageSelector/LanguageSelector";
import { useTranslation } from "react-i18next";

const URL = "http://localhost:8080/api/status";

function NavigationBar(): React.ReactElement {
  const [status, setStatus] = useState<number>();
  const [menuOpen, setMenuOpen] = useState<boolean>(false);

  useEffect(() => {
    fetch(URL)
      .then((response) => response.status)
      .then((data) => setStatus(data))
      .catch((err) => console.log(err));
  }, []);

  useEffect(() => {
    if (menuOpen) {
      document.body.classList.add(styles.noScroll);
    } else {
      document.body.classList.remove(styles.noScroll);
    }
  }, [menuOpen]);

  useEffect(() => {
    const handleResize = () => {
      if (window.innerWidth >= 768) {
        setMenuOpen(false);
      }
    };

    window.addEventListener('resize', handleResize);
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const { t } = useTranslation();
  const logo: React.ReactElement = (
    <div className={styles.navigationBarLogo}>
      <img
        alt="Golden Solution Logo"
        src={logoImage}
        className={styles.navigationBarLogoImage}
      ></img>
    </div>
  );

  const navigationBarItems: React.ReactElement = (
    <div className={`${styles.navigationBarMenu} ${menuOpen ? styles.navigationBarMenuOpen : ''}`}>
      <Link to="/Menu" className={styles.navigationBarMenuItem} onClick={() => setMenuOpen(false)}>
        {t("navigationBar.menu")}
      </Link>
      <Link to="/Restaurants" className={styles.navigationBarMenuItem} onClick={() => setMenuOpen(false)}>
        {t("navigationBar.restaurants")}
      </Link>
      <Link to="/Login" className={styles.navigationBarMenuItem} onClick={() => setMenuOpen(false)}>
        {t("navigationBar.login")}
      </Link>
      <Link to="/Register" className={styles.navigationBarMenuItem} onClick={() => setMenuOpen(false)}>
        {t("navigationBar.register")}
      </Link>
      <LanguageSelector />
      <label>{status}</label>
    </div>
  );

  return (
    <nav className={styles.navigationBar}>
      <div className={styles.navigationBarContent}>
        <div className={styles.navigationBarLeft}>
          {logo}
        </div>
        <div className={styles.navigationBarCenter}>
          {navigationBarItems}
        </div>
        <div className={styles.navigationBarRight}>
          {!menuOpen ? (
            <button className={styles.menuButton} onClick={() => setMenuOpen(true)}>
              ☰
            </button>
          ) : (
            <button className={styles.menuButton} onClick={() => setMenuOpen(false)}>
              ✕
            </button>
          )}
        </div>
      </div>
    </nav>
  );
}

export default NavigationBar;
