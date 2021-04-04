import Head from "next/head";
import styles from "../styles/Home.module.css";

const Home = () => {
  return (
    <div className={styles.container}>
      <Head>
        <title>Commander</title>
        <link rel="icon" href="/favicon.ico" />
      </Head>
      <main className={styles.main}>
        <h1>Hello</h1>
        <p>
          This is an app to share useful command lines accross multiple
          platforms!
        </p>
      </main>
    </div>
  );
};

export default Home;
