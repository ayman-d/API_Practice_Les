import React, { useState, useEffect } from "react";
import { useRouter } from "next/router";
import { useQuery } from "react-query";
import axios from "axios";
// import axios from "axios";

const Page = () => {
  const router = useRouter();
  const { query } = router || {};
  const { id } = query || {};

  const [loading, setLoading] = useState(false);
  const [command, setCommand] = useState({});

  useEffect(async () => {
    if (id) {
      setLoading(true);

      const res = await axios
        .get(`http://localhost:5000/api/commands/${id}`)
        .then((res) => res.data);

      setCommand(res);

      setLoading(false);
    }

    return () => {};
  }, [id]);

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h3>{command.id}</h3>
      <p>{command.line}</p>
      <p>{command.platform}</p>
    </div>
  );
};

export default Page;

// const router = useRouter();
//   const { id } = router.query;
//   console.log(id);

//   const getCommand = async () => {
//     const command = await fetch(`http://localhost:5000/api/commands/${id}`)
//       .then((res) => res.json())
//       .catch((err) => {
//         throw new Error("oh no!");
//       });
//     return command;
//   };

//   const { isLoading, isError, error, data } = useQuery(
//     ["command", id],
//     getCommand,
//     { retry: 0 }
//   );

//   if (isLoading) {
//     return <p>Loading...</p>;
//   }

//   if (isError) {
//     return <p>Error: No data found for this ID -- {error.message}</p>;
//   }

//   return (
//     <div>
//       <p>ID: {data.id}</p>
//       <p>Line: {data.line}</p>
//     </div>
//   );
