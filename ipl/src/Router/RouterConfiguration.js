import { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "../Images/PlayerHome";
import PlayerList from "../Players/PlayerList";
import PlayerNavigation from "../Players/Navigation";
import AddPlayers from "../Players/AddPlayers";
import Top5List from "../Players/Top5";
import Matches from "../Players/Matches";
import DateRange from "../Players/Date";

const RouterConfiguration = () => {
  return (
    <BrowserRouter>
      <PlayerNavigation />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/players" element={<PlayerList />} />
        <Route path="/top5" element={<Top5List/>}/>
        <Route path="/matches" element={<Matches/>}/>
        <Route path="/daterange" element={<DateRange/>}/>
        <Route path="/players/add" element={<AddPlayers />} />
      </Routes>
    </BrowserRouter>
  );
};
export default RouterConfiguration;
