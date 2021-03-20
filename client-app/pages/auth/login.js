import React, { useState, useEffect } from "react";
import axios from "axios";

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
    <div>
      <h1>Login Page</h1>
      <form method="post" onSubmit={onSubmit} id="loginForm">
        <div>
          <label htmlFor="username">Username</label>
          <input
            onChange={onChange}
            type="text"
            name="username"
            // required
            placeholder="username"
            value={credentials.username}
          ></input>
        </div>
        <div>
          <label htmlFor="password">Password</label>
          <input
            value={credentials.password}
            onChange={onChange}
            type="password"
            name="password"
            // required
            placeholder="password"
            value={credentials.password}
          ></input>
        </div>
        <div>
          <button type="submit">Login</button>
        </div>
      </form>
    </div>
  );
};

export default login;
