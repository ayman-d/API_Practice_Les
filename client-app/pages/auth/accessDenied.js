import React from "react";
import Link from "next/link";
import styles from "../../styles/auth/accessDenied.module.css";

const accessDenied = () => {
  return (
    <div className={styles.div}>
      <hr />
      <h2 className={styles.h2}>Oops! WARNING</h2>
      <p className={styles.p}>Looks like you don't have access to this page</p>
      <hr />
      <Link href="/">
        <button className={styles.button}>Home Page</button>
      </Link>
    </div>
  );
};

export default accessDenied;
