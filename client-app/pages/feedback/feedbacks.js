import Link from "next/link";
import React from "react";
import FeedbackList from "../../components/FeedbackList";

const feedbacks = () => {
  return (
    <div>
      Feedback Page
      <br />
      <Link href="/">
        <a>Home</a>
      </Link>
      <br />
      <FeedbackList />
    </div>
  );
};

export default feedbacks;
