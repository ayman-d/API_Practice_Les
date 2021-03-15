import React from "react";
import Link from "next/link";

const Command = ({ command }) => {
  return (
    <div>
      <Link href={`/commands/${command.id}`}>
        <a>
          <h3>{command.id}</h3>
          <p>{command.line}</p>
        </a>
      </Link>
    </div>
  );
};

export default Command;
