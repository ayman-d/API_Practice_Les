import React from "react";
import styles from "../styles/commands/command.module.css";

const Command = ({ command }) => {
  return (
    <div className={styles.container}>
      <h3>{command.id}</h3>
      <p>{command.line}</p>
    </div>
  );
};

export default Command;
