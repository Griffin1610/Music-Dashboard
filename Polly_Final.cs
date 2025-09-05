using System.Linq.Expressions;

namespace Polly_Final;

public class Polly_Final
{
    public static void Main()
    {
        //create Lists to store audio
        List<Track> tracks = new List<Track>();
        List<Audio> audioBooks = new List<Audio>();
        List<Podcast> podcasts = new List<Podcast>();
        
        string filePath = @"database.txt"; // Read data from txt file, ensure file is in .net8.0 file
        if (File.Exists(filePath)) {
            string[] lines = File.ReadAllLines(filePath);
            
            foreach (string line in lines)  //Read all Audio and separate types into respective lists
            {
                var fields = line.Split(',');
                string type = fields[0]; //index 0 set to type of audio. ie 'track','podcast' etc
                switch (type)
                {
                    case "Track": //string at index[0] of lines array
                        tracks.Add(new Track(fields[1], fields[2], fields[3], int.Parse(fields[4]), int.Parse(fields[5]), int.Parse(fields[6]), fields[7],fields[8]));
                        break;
                    case "Audio":
                        audioBooks.Add(new Audio(fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), double.Parse(fields[5]), fields[6]));
                        break;
                    case "Podcast":
                        podcasts.Add(new Podcast(fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), double.Parse(fields[5]), fields[6]));
                        break;
                }
            }
        }
        else //file path is not found or file DNE
        {
            Console.WriteLine("Unable to find database, make sure it is int the .net8.0 folder");
        }
        bool continueLoop = true;
        while (continueLoop)// loop and allow user input for menu choice
        {
            try
            {
                //handle menu choices
                Console.WriteLine("\nSelect an option by typing a number 1-10: ");
                Console.WriteLine(
                    "1. Print all entries in the database\n2. Print all Tracks\n3. Print all AudioBooks\n4. Print all Podcasts\n5. Print out all entries by any creator\n6. All Sorting Tasks\n7. Play audio of any item\n8. View Album Art from any album\n9. Add a Track to the Collection.\n10. Exit. ");
                int menuChoice = int.Parse(Console.ReadLine());

                //create list of allentries to help with below switch cases
                var allEntries = new List<object>();
                allEntries.AddRange(tracks);
                allEntries.AddRange(audioBooks);
                allEntries.AddRange(podcasts);

                switch (menuChoice)
                {
                    case 1: //print all entries in the database
                        Console.WriteLine("\n--- All Entries in Database ---");
                        // Combine all lists into a single collection
                        // Iterate over collection and write entry
                        foreach (var entry in allEntries)
                        {
                            Console.WriteLine(entry);
                        }

                        break;
                    case 2: // print all tracks
                        Console.WriteLine("\n--- All Tracks in Database ---");
                        for (int i = 0; i < tracks.Count; i++)
                        {
                            Console.WriteLine($"{tracks[i]}");
                        }

                        break;
                    case 3: // print all audio
                        Console.WriteLine("\n--- All Audio Books in Database ---");
                        for (int i = 0; i < audioBooks.Count; i++)
                        {
                            Console.WriteLine($"{audioBooks[i]}");
                        }

                        break;
                    case 4: // print all podcasts
                        Console.WriteLine("\n--- All Podcasts in Database ---");
                        for (int i = 0; i < podcasts.Count; i++)
                        {
                            Console.WriteLine($"{podcasts[i]}");
                        }

                        break;
                    case 5:
                        Console.WriteLine("\nEnter creator name: ");
                        string searchName =
                            Console.ReadLine().Trim()
                                .ToLower(); //convert to lower case and use ToLower() to find artists
                        Console.WriteLine($"\n--- Entries by {searchName} ---");
                        // Iterate over allEntries
                        foreach (var entry in allEntries)
                        {
                            switch (entry)
                            {
                                case Track track:
                                    if (track.Artist.ToLower().Contains(searchName))
                                    {
                                        Console.WriteLine(track);
                                    }

                                    break;
                                case Audio audio:
                                    if (audio.Author.ToLower().Contains(searchName))
                                    {
                                        Console.WriteLine(audio);
                                    }

                                    break;
                                case Podcast podcast:
                                    if (podcast.Host.ToLower().Contains(searchName))
                                    {
                                        Console.WriteLine(podcast);
                                    }

                                    break;
                            }
                        }

                        break;

                    case 6: // ALL SORTING TASKS
                        Console.WriteLine("\n--- Sorting Menu ---");
                        Console.WriteLine(
                            "1. Sort by descending Rating\n2. Sort by ascending Year\n3. Sort by lexicographical title");
                        int sortingChoice = int.Parse(Console.ReadLine());
                        switch (sortingChoice)
                        {
                            case 1: // Sort by rating in descending order
                                tracks = tracks.OrderByDescending(track => track.RollingStoneChartPosition).ToList();
                                audioBooks = audioBooks.OrderByDescending(audio => audio.Rating).ToList();
                                podcasts = podcasts.OrderByDescending(podcast => podcast.Rating).ToList();
                                break;
                            case 2: // Sort by year in ascending order
                                tracks = tracks.OrderBy(track => track.Year).ToList();
                                audioBooks = audioBooks.OrderBy(audio => audio.Year).ToList();
                                podcasts = podcasts.OrderBy(podcast => podcast.Year).ToList();
                                break;
                            case 3: // Sort by title in lexicographical order
                                tracks = tracks.OrderBy(track => track.Title).ToList();
                                audioBooks = audioBooks.OrderBy(audio => audio.Title).ToList();
                                podcasts = podcasts.OrderBy(podcast => podcast.Title).ToList();
                                break;
                            default:
                                Console.WriteLine("Invalid sorting option. Returning to main menu.");
                                break;
                        }

                        //update all entries with new sorted order
                        allEntries.Clear();
                        allEntries.AddRange(tracks);
                        allEntries.AddRange(audioBooks);
                        allEntries.AddRange(podcasts);

                        Console.WriteLine("\n--- Sorting complete! Use choice 1 tp print items ---");
                        break;

                    case 7: //play audio of each item **STRETCH GOAL 1**
                        //write all entries so user knows possible inputs
                        foreach (var entry in allEntries)
                        {
                            switch (entry)
                            {
                                case Track track:
                                    Console.WriteLine(track.Title);
                                    break;
                                case Audio audio:
                                    Console.WriteLine(audio.Title);
                                    break;
                                case Podcast podcast:
                                    Console.WriteLine(podcast.Title);
                                    break;
                            }
                        }

                        Console.WriteLine(
                            "\nEnter the name of the song or podcast you want to play from the list above: ");
                        //show user possible items
                        string searchForName =
                            Console.ReadLine().Trim().ToLower(); // Convert input to lowercase and use ToLower()
                        var Item = allEntries.FirstOrDefault(entry =>
                        {
                            switch (entry)
                            {
                                case Track track:
                                    return track.Title.ToLower().Contains(searchForName);
                                case Audio audio:
                                    return audio.Title.ToLower().Contains(searchForName);
                                case Podcast podcast:
                                    return podcast.Title.ToLower().Contains(searchForName);
                                default:
                                    return false;
                            }
                        });
                        if (Item != null)
                        {
                            string link = string.Empty;
                            // Extract link from the selected item
                            switch (Item)
                            {
                                case Track track:
                                    link = track.Link;
                                    break;
                                case Audio audio:
                                    link = audio.Link;
                                    break;
                                case Podcast podcast:
                                    link = podcast.Link;
                                    break;
                            }

                            if (!string.IsNullOrEmpty(link) || link != "null")
                            {
                                // Open the link in the default web browser
                                Console.WriteLine($"Opening {link} in new browser!");
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = link,
                                    UseShellExecute = true
                                });
                            }
                            else
                            {
                                Console.WriteLine("No link available for this item.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }

                        break;
                    case 8: //view album art of each track **STRETCH GOAL 2**
                        foreach (var entry in allEntries)
                        {
                            switch (entry)
                            {
                                case Track track:
                                    Console.WriteLine(track.Title);
                                    break;
                            }
                        }

                        Console.WriteLine("\nEnter the track title from list above to view album art:");
                        string trackTitle = Console.ReadLine().Trim().ToLower();

                        var selectedTrack = tracks.FirstOrDefault(track => track.Title.ToLower() == trackTitle);
                        if (selectedTrack != null)
                        {
                            if (!string.IsNullOrEmpty(selectedTrack.Image))
                            {
                                Console.WriteLine($"Opening album art for '{selectedTrack.Title}'...");
                                // Open the image URL in the default web browser
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = selectedTrack.Image,
                                    UseShellExecute = true
                                });
                            }
                            else
                            {
                                Console.WriteLine($"No art available for '{selectedTrack.Title}'.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Track not found in the database.");
                        }

                        break;
                    
                     case 9: // add a track to the list **STRECH GOAL 3
                        Console.WriteLine("\n--- Add a New Track Fitting The Following Description ---");
                        Console.WriteLine("Title,Artist,Album,Year,Duration (in seconds),Rolling Stone Chart Position,Link,Album Art URL");
                            
                        // Prompt the user to enter each csv
                            Console.Write("Enter the title: ");
                            string title = Console.ReadLine();
                        
                            Console.Write("Enter the artist: ");
                            string artist = Console.ReadLine();
                        
                            Console.Write("Enter the album: ");
                            string album = Console.ReadLine();
                        
                            Console.Write("Enter the release year: ");
                            if (!int.TryParse(Console.ReadLine(), out int year)) {
                                throw new FormatException("Year must be a valid number.");
                            }
                            Console.Write("Enter the duration in seconds: ");
                            if (!int.TryParse(Console.ReadLine(), out int duration)) {
                                throw new FormatException("Duration must be a valid number.");
                            }
                            Console.Write("Enter the Rolling Stone chart position: ");
                            if (!int.TryParse(Console.ReadLine(), out int chartPosition)) {
                                throw new FormatException("Chart position must be a valid number.");
                            }
                            Console.Write("Enter the link (or 'null' if NA): ");
                            string links = Console.ReadLine();
                        
                            Console.Write("Enter the album art URL (or 'null' if NA): ");
                            string albumArt = Console.ReadLine();

                            //Create track from user inputs
                            Track newTrack = new Track(title, artist, album, year, duration, chartPosition, links, albumArt);
                            tracks.Add(newTrack);

                            //Write to File
                            string newEntry = $"Track,{title},{artist},{album},{year},{duration},{chartPosition},{links},{albumArt}";
                            File.AppendAllText(filePath, newEntry + Environment.NewLine);
                            Console.WriteLine("\n--- New track added successfully! ---");
                        break;
                    
                    case 10: //exit program
                        Console.WriteLine("\n--- Now Leaving Program---");
                        System.Environment.Exit(0);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
    