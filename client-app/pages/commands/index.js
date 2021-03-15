import React, { useState, useEffect } from "react";
import Command from "../../components/Command";
import { useQuery } from "react-query";
import axios from "axios";
import Link from "next/link";

export default function SomethingElse() {
  const [commands, setCommands] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(async () => {
    setLoading(true);
    const res = await axios
      .get("http://localhost:5000/api/commands")
      .then((result) => result.data);

    setLoading(false);

    setCommands(res);
    return () => {};
  }, []);

  if (loading) {
    return <div>loading...</div>;
  }

  return (
    <div>
      <Link href="/commands/create">
        <button>Create new command</button>
      </Link>
      <h2>Commands</h2>
      <ul>
        {commands.map((command) => (
          <li key={command.id}>
            <Command command={command} />
          </li>
        ))}
      </ul>
    </div>
  );
}

// const getCommands = async () => {
//   const commands = await axios("http://localhost:5000/api/commands").then(
//     (res) => res.data
//   );
//   return commands;
// };

// // getCommands();

// const { isLoading, isError, error, data } = useQuery(
//   ["commands"],
//   getCommands,
//   { retry: 0 }
// );

// if (isLoading) {
//   return <p>loading...</p>;
// }

// if (isError) {
//   console.log(error);
//   return <p>Error on page - Please contact a site administrator</p>;
// }

// return (
//   <div>
//     <h3>Something Else</h3>
//     <ul>
//       {data.map((command) => (
//         <li key={command.id}>
//           <p>{command.id}</p>
//           <p>{command.line}</p>
//         </li>
//       ))}
//     </ul>
//   </div>
// );
