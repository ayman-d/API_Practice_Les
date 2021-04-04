import React, { useState, useEffect } from "react";
import axios from "axios";
import styles from "../../styles/auth/login.module.css";

const login = () => {
  const [credentials, setCredentials] = useState({
    username: "",
    password: "",
  });

  const onChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
  };

  const onSubmit = (e) => {
    e.preventDefault();

    axios
      .post("http://localhost:5000/api/auth/login", {
        email: credentials.username,
        password: credentials.password,
      })
      .then((res) => console.log(res))
      .catch((err) => console.log(err.response));

    // window.location.href = "/";
  };

  return (
    <div className={styles.container}>
      <h1 className={styles.h1}>Log In</h1>
      <form method="POST" onSubmit={onSubmit} id="loginForm">
        <div>
          <label className={styles.label} htmlFor="username">
            Username
          </label>
          <input
            className={styles.input}
            onChange={onChange}
            type="text"
            name="username"
            // required
            placeholder="Username"
            value={credentials.username}
          ></input>
        </div>
        <div>
          <label className={styles.label} htmlFor="password">
            Password
          </label>
          <input
            className={styles.input}
            value={credentials.password}
            onChange={onChange}
            type="password"
            name="password"
            // required
            placeholder="Password"
            value={credentials.password}
          ></input>
        </div>
        <div>
          <button className={styles.button} type="submit">
            Login
          </button>
        </div>
      </form>
    </div>
  );
};

export default login;
