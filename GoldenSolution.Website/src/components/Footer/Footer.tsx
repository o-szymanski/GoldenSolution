import React from "react";
import styles from "./Footer.module.css";
import facebook from "../../assets/socials/facebook.svg";
import instagram from "../../assets/socials/instagram.svg";
import youtube from "../../assets/socials/youtube.svg";
import twitter from "../../assets/socials/twitter.svg";
import linkedin from "../../assets/socials/linkedin-in.svg";
import mail from "../../assets/socials/envelope-solid.svg";
import logoImage from "../../assets/socials/logo.svg";
import { Link } from "react-router-dom";

function Footer(): React.ReactElement {
  const socialMedia: React.ReactElement = (
    <div className={styles.footerSocialMedia}>
      <span className={styles.footerLine}>
        <hr />
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution Facebook" src={facebook} />
        </a>
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution Instagram" src={instagram} />
        </a>
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution YouTube" src={youtube} />
        </a>
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution X/Twitter" src={twitter} />
        </a>
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution LinkedIn" src={linkedin} />
        </a>
      </span>
      <span className={styles.footerSocialMediaItem}>
        <a href="#">
          <img alt="Golden Solution Mail" src={mail} />
        </a>
      </span>
      <span className={styles.footerLine}>
        <hr />
      </span>
    </div>
  );
  const logo: React.ReactElement = (
    <div className={styles.footerLogo}>
      <img
        alt="Golden Solution Logo"
        src={logoImage}
        className={styles.footerLogoImage}
      ></img>
    </div>
  );
  const copyright: React.ReactElement = (
    <div className={styles.footerCopyright}>
      <p>Copyright &copy; {new Date().getFullYear()} Golden Solution</p>
    </div>
  );
  const siteMap: React.ReactElement = (
    <div className={styles.footerSiteMap}>
      <span>
        <Link to="/">Home</Link>
      </span>
      <span>
        <Link to="/careers">Careers</Link>
      </span>
      <span>
        <Link to="#">About</Link>
      </span>
      <span>
        <Link to="#">Contact</Link>
      </span>
    </div>
  );

  return (
    <footer className={styles.footer}>
      <div className={styles.footerContent}>
        {socialMedia}
        {logo}
        {copyright}
        {siteMap}
      </div>
    </footer>
  );
}

export default Footer;