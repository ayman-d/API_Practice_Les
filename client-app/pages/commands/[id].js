import React, { useState, useEffect } from "react";
import Command from "../../components/Command";
import { useRouter } from "next/router";
import { useQuery } from "react-query";
import axios from "axios";
// import axios from "axios";

const Page = () => {
  const router = useRouter();
  // const { query } = router || {};
  // const { id } = query || {};
  const id = router.query.id;

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
