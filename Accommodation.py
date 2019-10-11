class Accommodation:
    def CountAccommodationWaysMemo(self, floorCapacities, noOfPeople):
        floorCapacities.sort(reverse=True)

        dp = [[-1 for _ in range(noOfPeople + 1)] for _ in range(len(floorCapacities))]

        def CountStartAccomodationFrom(floor, noOfPeopleLocal):
            # Solve small sub-problems
            remaining = noOfPeopleLocal - floorCapacities[floor]

            # if remaining < 0: return
            if remaining == 0:
                dp[floor][noOfPeopleLocal] = 1
                return 1

            # Divide & Combine
            levelCount = 0
            for lev in range(floor, len(floorCapacities)):
                if remaining < floorCapacities[lev]: continue

                if dp[lev][remaining] == -1:
                    dp[lev][remaining] = CountStartAccomodationFrom(lev, remaining)
                levelCount += dp[lev][remaining]

            dp[floor][noOfPeopleLocal] = levelCount
            return levelCount

        finalCount = 0
        for level in range(len(floorCapacities)):
            finalCount += CountStartAccomodationFrom(level, noOfPeople)

        return finalCount

    def CountAccommodationWaysTab(self, floorCapacities, noOfPeople):
        floorCapacities.sort(reverse=True)

        dp = [[0 for _ in range(noOfPeople + 1)] for _ in range(len(floorCapacities))]

        row = len(floorCapacities)

        for currentNoOfPeople in range(floorCapacities[- 1], noOfPeople + 1):
            row -= 1
            if row < 0: row = 0
            for floor in range(row, len(floorCapacities)):
                remaining = currentNoOfPeople - floorCapacities[floor]

                # Solve small sub-problems
                if remaining == 0:
                    dp[floor][currentNoOfPeople] = 1
                    continue

                # Divide & Combine
                levelCount = 0
                for level in range(floor, len(floorCapacities)):
                    if remaining < floorCapacities[level]: continue
                    levelCount += dp[level][remaining]

                dp[floor][currentNoOfPeople] = levelCount

        finalCount = 0
        for floor in range(len(floorCapacities)):
            finalCount += dp[floor][noOfPeople]

        return finalCount

    @staticmethod
    def Work():
        # noOfPeople = 5
        # floorCapacities = [1, 2, 3]  # Ans: 5

        # noOfPeople = 6
        # floorCapacities = [1, 3, 5]  # Ans: 4

        noOfPeople = 10
        floorCapacities = [2, 4, 5, 7, 8]  # Ans: 5

        accommodationWays = Accommodation().CountAccommodationWaysTab(floorCapacities, noOfPeople)
        print(accommodationWays)
