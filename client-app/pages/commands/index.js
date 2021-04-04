import React, { useState, useEffect } from "react";
import Command from "../../components/Command";
import axios from "axios";
import Link from "next/link";
import styles from "../../styles/commands/commands.module.css";

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
          <Link href={`/commands/${command.id}`} key={command.id}>
            <li className={styles.li}>
              <Command command={command} />
            </li>
          </Link>
        ))}
      </ul>
    </div>
  );
}
