import React from "react";
import { useRouter } from "next/router";
import { useQuery } from "react-query";

const Page = () => {
  const router = useRouter();
  const id = router.query.id;

  const getCommand = async () => {
    const command = fetch(`http://localhost:5000/api/commands/${id}`)
      .then((res) => res.json())
      .then((result) => result);
    return command;
  };

  const { isLoading, isError, error, data } = useQuery(
    ["command", id],
    getCommand,
    { retry: 0 }
  );

  if (isLoading) {
    return <p>Loading...</p>;
  }

  if (isError) {
    return <p>Error: No data found for this ID</p>;
  }

  return (
    <div>
      <p>ID: {data.id}</p>
      <p>Line: {data.line}</p>
      {/* <ul>
        {data.feedbacks.forEach((feedback) => {
          <li key={feedback.id}>
            <p>Message: {feedback.message}</p>
          </li>;
        })}
      </ul> */}
    </div>
  );
};

export default Page;
