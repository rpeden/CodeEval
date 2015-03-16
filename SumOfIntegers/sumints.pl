open(INFILE, $ARGV[0]) or die("Cannot open file $_[0] for reading: $!");
my $sum = 0;
while(my $line = <INFILE>) {
	next if($line =~ m/^s$/); 
	$line =~ s/(^s|s*$)//g; # remove leading and trailing space
	$sum += $line;
}
print $sum;
close(INFILE);