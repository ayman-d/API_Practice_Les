import React from "react";
import { useQuery } from "react-query";
import axios from "axios";

export default function SomethingElse() {
  const getCommands = async () => {
    const commands = await axios("http://localhost:5000/api/commands").then(
      (res) => res.data
    );
    return commands;
  };

  // getCommands();

  const { isLoading, isError, error, data } = useQuery(
    ["commands"],
    getCommands,
    { retry: 0 }
  );

  if (isLoading) {
    return <p>loading...</p>;
  }

  if (isError) {
    console.log(error);
    return <p>Error on page - Please contact a site administrator</p>;
  }

  return (
    <div>
      <h3>Something Else</h3>
      <ul>
        {data.map((command) => (
          <li key={command.id}>
            <p>{command.id}</p>
            <p>{command.line}</p>
          </li>
        ))}
      </ul>
    </div>
  );
}
