import Head from "next/head";
import Link from "next/link";
import styles from "../styles/Home.module.css";
import axios from "axios";

const Home = () => {
  return (
    <div className={styles.container}>
      <Head>
        <title>Commander</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <main className={styles.main}>
        <h1>Hello</h1>
      </main>
    </div>
  );
};

export default Home;
