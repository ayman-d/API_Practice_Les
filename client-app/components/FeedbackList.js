import React from "react";
import useFeedbacks from "../hooks/feedbacks";

const FeedbackList = () => {
  const feedbacks = useFeedbacks();

  // console.log(feedbacks.data);

  if (feedbacks.isLoading) {
    return <p>loading...</p>;
  }

  if (feedbacks.isError) {
    return <p>Error!</p>;
  }

  return (
    <div>
      feedback list
      <ul>
        {feedbacks.data.map((feedback) => (
          <li key={feedback.id}>
            <p>{feedback.id}</p>
            <p>{feedback.message}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default FeedbackList;
