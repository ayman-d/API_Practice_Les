import axios from "axios";
import React, { useEffect, useState } from "react";

const create = () => {
  const [newCommand, setNewCommand] = useState({
    howTo: "",
    line: "",
    platform: "",
  });

  const onChange = (e) => {
    setNewCommand({ ...newCommand, [e.target.name]: e.target.value });
  };
  //   console.log(newCommand);

  const onSubmit = (e) => {
    e.preventDefault();
    axios
      .post("http://localhost:5000/api/commands", {
        howTo: newCommand.howTo,
        line: newCommand.line,
        platform: newCommand.platform,
      })
      .then((res) => {
        if (res.status === 201) {
          console.log("Success!!!");
        } else if (res.response.status === 400) {
          console.log("Request was not filled correctly");
        } else {
          console.log("Error on page, please contact a site administrator");
        }
      });
  };

  return (
    <div>
      <h1>Create Page</h1>
      <form method="POST" id="createCommandForm" onSubmit={onSubmit}>
        <div>
          <label htmlFor="howTo">How To</label>
          <input
            type="text"
            name="howTo"
            id="howTo"
            onChange={onChange}
            required
          ></input>
        </div>
        <div>
          <label htmlFor="line">Line</label>
          <input
            type="text"
            name="line"
            id="line"
            onChange={onChange}
            required
          ></input>
        </div>
        <div>
          <label htmlFor="platform">Platform</label>
          <input
            type="text"
            name="platform"
            id="platform"
            onChange={onChange}
            required
          ></input>
        </div>
        <div>
          <button type="submit">Submit</button>
        </div>
      </form>
    </div>
  );
};

export default create;
