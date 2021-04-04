import "../styles/globals.css";
import Link from "next/link";
import axios from "axios";

// DONT FORGET THESE axios interceptors
axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response.status === 401) {
      window.location.href = "/auth/login";
    }

    if (error.response.status === 403) {
      window.location.href = "/auth/accessDenied";
    }

    return error;
  }
);

// this is needed for the cookie
axios.defaults.withCredentials = true;
// end of axios interceptors

function MyApp({ Component, pageProps }) {
  return (
    <div>
      <Link href="/">
        <a>Home</a>
      </Link>
      <br />
      <Link href="/commands">
        <a>Commands</a>
      </Link>
      <br />
      <Link href="/auth/login">
        <a>Login</a>
      </Link>
      <Component {...pageProps} />
    </div>
  );
}

export default MyApp;
