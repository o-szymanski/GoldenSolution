import React from "react";
import { useTranslation } from "react-i18next";

function Menu(): React.ReactElement {
  const { t } = useTranslation();
  const greeting = t("greeting", {
    name: "XYZ",
  });

  return <h1>{greeting}</h1>;
}

export default Menu;
