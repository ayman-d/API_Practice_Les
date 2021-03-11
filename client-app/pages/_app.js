import "../styles/globals.css";
import { QueryClient, QueryClientProvider } from "react-query";
import Link from "next/link";
import axios from "axios";

// DONT FORGET THESE EVERRRRRRRRRRRRRR
axios.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response.status === 401) {
      window.location.href = "/auth/login";
    }
    return error;
  }
);

axios.defaults.withCredentials = true;

const queryClient = new QueryClient();

function MyApp({ Component, pageProps }) {
  return (
    <QueryClientProvider client={queryClient}>
      <Link href="/commands">
        <a>Commands</a>
      </Link>
      <br />
      <Link href="/auth/login">
        <a>Login</a>
      </Link>
      <Component {...pageProps} />
    </QueryClientProvider>
  );
}

export default MyApp;
