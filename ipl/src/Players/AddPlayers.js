import { useState } from "react";
import { addPlayer } from "../Services/PlayerApiServices";

const AddPlayers = () => {
  const [player, setPlayer] = useState({
    player_name: "",
    team_id: "",
    role: "",
    age: "",
    matches_played: "",
});

  const onChange = (e) => {
    setPlayer({ ...player, [e.target.id]: e.target.value });
  };

  async function handleSubmit(e)  {
    e.preventDefault();
    const res = await addPlayer(player);
    console.log(res);

    if (!res) {
      alert("Player added successfully");
    } else {
      alert("Failed to add player");
    }
  };

  return (
    <>
      <h1>Add a new Player</h1>
      <form className="form-group" >
        <div>
          Player Name :{" "}
          <input
            className="form-control"
            value={player.player_name}
            onChange={onChange}
            type="text"
            id="player_name"
          />
        </div>
        <div>
          Team id :{" "}
          <input
            className="form-control"
            value={player.team_id}
            onChange={onChange}
            type="number"
            id="team_id"
          />
        </div>
        <div>
          Player Role :{" "}
          <input
            className="form-control"
            value={player.role}
            onChange={onChange}
            type="text"
            id="role"
          />
        </div>
        <div>
          Player Age :{" "}
          <input
            className="form-control"
            value={player.age}
            onChange={onChange}
            type="number"
            id="age"
          />
        </div>
        <div>
          Matches Played :{" "}
          <input
            className="form-control"
            value={player.matches_played}
            onChange={onChange}
            type="number"
            id="matches_played"
          />
        </div>

        <button
          className="btn btn-primary m-2 p-3"
          type="submit"
          onClick={handleSubmit}
        >
          Add new Player
        </button>
      </form>
    </>
  );
};
export default AddPlayers;
