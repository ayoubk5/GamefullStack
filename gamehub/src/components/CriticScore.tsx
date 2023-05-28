import { Badge } from "@chakra-ui/react";
interface Props {
  score: number;
}
const CriticScore = ({ score }: Props) => {
  const color = score > 75 ? "green" : score > 60 ? "yellow" : "";
  return (
    <Badge rounded={5} colorScheme={color} paddingX={2} fontSize="14px">
      {score}
    </Badge>
  );
};

export default CriticScore;
