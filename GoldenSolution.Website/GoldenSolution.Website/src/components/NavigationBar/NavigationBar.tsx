import styles from "./NavigationBar.module.css"
import logoImage from "../../assets/socials/logo.svg"
import { Link } from "react-router-dom"

function NavigationBar(): React.ReactElement {
    const logo: React.ReactElement = <div className={styles.navigationBarLogo}>
        <img alt="Golden Solution Logo" src={logoImage} className={styles.navigationBarLogoImage}></img>
    </div>
    const navigationBarItems: React.ReactElement = <div className={styles.navigationBarMenu}>
        <Link to='/Menu' className={styles.navigationBarMenuItem}> MENU </Link>
        <Link to='/Restaurants' className={styles.navigationBarMenuItem}> RESTAURANTS </Link>
        <Link to='/Login' className={styles.navigationBarMenuItem}> LOGIN </Link>
        <Link to='/Register' className={styles.navigationBarMenuItem}> REGISTER </Link>
        POLISH | ENGLISH
    </div>

    return (
        <nav className={styles.navigationBar}>
            {logo}
            {navigationBarItems}
        </nav>
    );
}

export default NavigationBar